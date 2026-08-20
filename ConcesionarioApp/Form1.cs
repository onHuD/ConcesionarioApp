using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConcesionarioApp
{
    public partial class Form1 : Form
    {
        private readonly AutoDAO autoDAO = new AutoDAO();
        private int idSeleccionado = 0; // 0 significa "ninguno seleccionado"

        // Indices para búsqueda rapida: clave = marca/modelo en minusculas, valor = autos que coinciden
        private Dictionary<string, List<Auto>> indicePorMarca = new Dictionary<string, List<Auto>>();
        private Dictionary<string, List<Auto>> indicePorModelo = new Dictionary<string, List<Auto>>();
        private List<Auto> todosLosAutos = new List<Auto>(); // Lista completa de autos para reconstruir índices
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarAutos();
        }

        // Trae todos los autos de la base, los muestra en la grilla y reconstruye los índices
        private void CargarAutos()
        {
            try
            {
                List<Auto> autos = autoDAO.ObtenerTodos();

                todosLosAutos = autos; // Guardamos la lista completa para búsquedas futuras
                ConstruirIndices(autos);

                dgvAutos.DataSource = null;
                dgvAutos.DataSource = autos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los autos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Recorre la lista de autos una sola vez y los agrupa en los diccionarios
        // por marca y por modelo (en minúsculas, para que la búsqueda no distinga mayúsculas).
        private void ConstruirIndices(List<Auto> autos)
        {
            indicePorMarca.Clear();
            indicePorModelo.Clear();

            foreach (Auto auto in autos)
            {
                string marca = auto.Marca.ToLower();
                string modelo = auto.Modelo.ToLower();

                // Si la clave no existe todavía, creamos la lista vacía antes de agregar
                if (!indicePorMarca.ContainsKey(marca))
                indicePorMarca[marca] = new List<Auto>();
                indicePorMarca[marca].Add(auto);

                if (!indicePorModelo.ContainsKey(modelo))
                indicePorModelo[modelo] = new List<Auto>();
                indicePorModelo[modelo].Add(auto);
            }
        }

        // Valida que los datos ingresados en el formulario sean correctos
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtMarca.Text) ||
                string.IsNullOrWhiteSpace(txtModelo.Text) ||
                string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("Marca, Modelo y Color son obligatorios.", "Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtAnio.Text, out _))
            {
                MessageBox.Show("El año debe ser un número entero (ej: 2024).", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("El precio debe ser un número válido (ej: 21000.50).", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("El stock debe ser un número entero (ej: 3).", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Construye un objeto Auto a partir de lo que hay escrito en los TextBox
        private Auto ObtenerAutoDelFormulario()
        {
            return new Auto
            {
                Id = idSeleccionado,
                Marca = txtMarca.Text.Trim(),
                Modelo = txtModelo.Text.Trim(),
                Anio = int.Parse(txtAnio.Text),
                Color = txtColor.Text.Trim(),
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text)
            };
        }

        private bool ExisteAuto(string marca, string modelo, int anio)
        {
            string claveMarca = marca.ToLower();

            if(indicePorMarca.TryGetValue(claveMarca, out List<Auto> autosDeEstaMarca))
            {
                return autosDeEstaMarca.Any(a =>
                a.Modelo.ToLower() == modelo.ToLower() && a.Anio == anio);
            }

            return false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                Auto nuevoAuto = ObtenerAutoDelFormulario();

                if (ExisteAuto(nuevoAuto.Marca, nuevoAuto.Modelo, nuevoAuto.Anio))
                {
                    MessageBox.Show("Ya existe un auto con la misma marca, modelo y año.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (autoDAO.Agregar(nuevoAuto))
                {
                    MessageBox.Show("Auto agregado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarAutos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el auto: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná un auto de la lista para modificar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                Auto autoModificado = ObtenerAutoDelFormulario();
                if (autoDAO.Modificar(autoModificado))
                {
                    MessageBox.Show("Auto modificado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarAutos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el auto: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná un auto de la lista para eliminar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Seguro que querés eliminar este auto?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                if (autoDAO.Eliminar(idSeleccionado))
                {
                    MessageBox.Show("Auto eliminado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarAutos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el auto: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // Busca coincidencia EXACTA (case-insensitive - caso sensitivo) por marca o por modelo,
        // consultando directamente los diccionarios en vez de recorrer toda la lista.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string termino = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(termino))
            {
                MessageBox.Show("Escribí una marca o modelo para buscar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Auto> resultados = BuscarPorMarcaOModelo(termino);

            if (resultados.Count == 0)
            {
                MessageBox.Show("No se encontraron autos con esa marca o modelo (recordá: la búsqueda es exacta).",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvAutos.DataSource = null;
            dgvAutos.DataSource = resultados;
        }

        // Consulta ambos diccionarios (O(1) cada uno) y combina los resultados sin duplicados
        private List<Auto> BuscarPorMarcaOModelo(string termino)
        {
            var resultados = new List<Auto>();

            if (indicePorMarca.TryGetValue(termino, out List<Auto> porMarca))
            {
                resultados.AddRange(porMarca);
            }

            if (indicePorModelo.TryGetValue(termino, out List<Auto> porModelo))
            {
                foreach (Auto auto in porModelo)
                {
                    if (!resultados.Contains(auto))
                        resultados.Add(auto);
                }
            }

            if (resultados.Count == 0)
            {
                resultados = todosLosAutos
               .Where(a => a.Marca.ToLower().Contains(termino) || a.Modelo.ToLower().Contains(termino)).ToList();
                
            }

            return resultados;
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarAutos();
        }

        private void LimpiarFormulario()
        {
            idSeleccionado = 0;
            txtMarca.Clear();
            txtModelo.Clear();
            txtAnio.Clear();
            txtColor.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            dgvAutos.ClearSelection();
        }

        // Cuando el usuario hace click en una fila de la grilla,
        // cargamos esos datos en los TextBox para poder editarlos o eliminarlos.
        private void dgvAutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // click en el encabezado, ignorar

            DataGridViewRow fila = dgvAutos.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
            txtMarca.Text = fila.Cells["Marca"].Value.ToString();
            txtModelo.Text = fila.Cells["Modelo"].Value.ToString();
            txtAnio.Text = fila.Cells["Anio"].Value.ToString();
            txtColor.Text = fila.Cells["Color"].Value.ToString();
            txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
            txtStock.Text = fila.Cells["Stock"].Value.ToString();
        }
    }
}