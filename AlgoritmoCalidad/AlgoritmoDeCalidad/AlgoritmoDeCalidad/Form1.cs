using Bunifu.UI.WinForms.BunifuButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoDeCalidad
{

   
    public partial class AlgoritmoDeCalidad : Form
    {
        public AlgoritmoDeCalidad()
        {
            InitializeComponent();
        }

        private const int MIN_REQUERIDO = 14;
        private int ixPanel = 0;
        private List<Panel> Panels { get; set; }
        private Funcionabilidad FuncResultados { get; set; }
        private Eficiencia EficResultados { get; set; }
        private Fiabilidad FiabResultados { get; set; }
        private Mantenibilidad MantResultados { get; set; }
        private Usabilidad UsabResultados { get; set; }
        private Portabilidad PortResultados { get; set; }

        private List<BunifuButton> Buttons { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            FuncResultados = new Funcionabilidad();
            EficResultados = new Eficiencia();
            FiabResultados = new Fiabilidad();
            MantResultados = new Mantenibilidad();
            UsabResultados = new Usabilidad();
            PortResultados = new Portabilidad();

            Panels = new List<Panel>
            {
                this.FuncionabilidadPanel,
                this.EficienciaPanel,
                this.FiabilidadPanel,
                this.MantenibPanel,
                this.UsabilidadPanel,
                this.PortabilidadPanel,
                this.ResultadosPanel
            };

            Buttons = new List<BunifuButton>
            {
                FunciButton,
                EficiButton,
                FiabiButton,
                ManteButton,
                UsabiButton,
                PortaButton,
                ResButton
            };
        }

        private void ProximaEtapa(object sender, EventArgs e)
        {
            Buttons[ixPanel].Enabled = false;
            Panel proximoPanel = Panels[++ixPanel];
            proximoPanel.Show();
            Buttons[ixPanel].Enabled = true;

            if(proximoPanel.Name == nameof(this.ResultadosPanel))
            {
                NextButton.Enabled = false;
                Resultado.Text = EsSatisfactorio() ? "Satisfactorio" : "No satisfactorio";
            }
        }

        private bool EsSatisfactorio()
        {
            int promedio = 0;

            try
            {
                promedio = FuncResultados.GetPuntaje() +
                        EficResultados.GetPuntaje() +
                        FiabResultados.GetPuntaje() +
                        MantResultados.GetPuntaje() +
                        UsabResultados.GetPuntaje() +
                        PortResultados.GetPuntaje();
                promedio = Convert.ToInt32(promedio / 6);
            }
            catch(InvalidOperationException ex)
            {
                return false;
            }
            return promedio >= MIN_REQUERIDO;
        }

        #region Funcionabilidad
        private void FuncA1_Click(object sender, EventArgs e) => FuncResultados.SeguridadAcceso = (int)Puntaje.Mala;
        private void FuncA2_Click(object sender, EventArgs e) => FuncResultados.SeguridadAcceso = (int)Puntaje.Regular;
        private void FuncA3_Click(object sender, EventArgs e) => FuncResultados.SeguridadAcceso = (int)Puntaje.Buena;

        private void FuncB1_Click(object sender, EventArgs e) => FuncResultados.Exactitud = (int)Puntaje.Mala;
        private void FuncB2_Click(object sender, EventArgs e) => FuncResultados.Exactitud = (int)Puntaje.Regular;
        private void FuncB3_Click(object sender, EventArgs e) => FuncResultados.Exactitud = (int)Puntaje.Buena;

        private void BarAdecuacion_Scroll(object sender, EventArgs e)
        {
            int porcentaje = this.BarAdecuacion.Value;
            if (porcentaje >= 0 && porcentaje <= 29)
                FuncResultados.Adecuacion = (int)Puntaje.Mala;
            if (porcentaje >= 30 && porcentaje <= 69)
                FuncResultados.Adecuacion = (int)Puntaje.Regular;
            if (porcentaje >= 70 && porcentaje <= 100)
                FuncResultados.Adecuacion = (int)Puntaje.Buena;
        }
        #endregion

        #region Eficiencia
        private void BarRecursos_Scroll(object sender, EventArgs e)
        {
            int porcentaje = this.BarRecursos.Value;
            if (porcentaje >= 0 && porcentaje <= 10)
                EficResultados.Recursos = (int)Puntaje.Buena;
            if (porcentaje >= 11 && porcentaje <= 40)
                EficResultados.Recursos = (int)Puntaje.Regular;
            if (porcentaje >= 41 && porcentaje <= 100)
                EficResultados.Recursos = (int)Puntaje.Mala;
        }

        private void EficB1_Click(object sender, EventArgs e) => EficResultados.Comportamiento = (int)Puntaje.Mala;
        private void EficB2_Click(object sender, EventArgs e) => EficResultados.Comportamiento = (int)Puntaje.Regular;
        private void EficB3_Click(object sender, EventArgs e) => EficResultados.Comportamiento = (int)Puntaje.Buena;

        private void BarFuncEficiente_Scroll(object sender, EventArgs e)
        {
            int porcentaje = this.BarFuncEficiente.Value;
            if (porcentaje >= 0 && porcentaje <= 10)
                EficResultados.Funcionamiento = (int)Puntaje.Buena;
            if (porcentaje >= 11 && porcentaje <= 40)
                EficResultados.Funcionamiento = (int)Puntaje.Regular;
            if (porcentaje >= 41 && porcentaje <= 100)
                EficResultados.Funcionamiento = (int)Puntaje.Mala;
        }
        #endregion

        #region Fiabilidad
        private void FiabA1_Click(object sender, EventArgs e) => FiabResultados.Tolerancia = (int)Puntaje.Mala;
        private void FiabA2_Click(object sender, EventArgs e) => FiabResultados.Tolerancia = (int)Puntaje.Regular;
        private void FiabA3_Click(object sender, EventArgs e) => FiabResultados.Tolerancia = (int)Puntaje.Buena;

        private void FiabB1_Click(object sender, EventArgs e) => FiabResultados.Recuperacion = (int)Puntaje.Mala;
        private void FiabB2_Click(object sender, EventArgs e) => FiabResultados.Recuperacion = (int)Puntaje.Regular;
        private void FiabB3_Click(object sender, EventArgs e) => FiabResultados.Recuperacion = (int)Puntaje.Buena;

        private void BarMadurez_Scroll(object sender, EventArgs e)
        {
            int porcentaje = this.BarMadurez.Value;
            if (porcentaje >= 0 && porcentaje <= 29)
                FiabResultados.Madurez = (int)Puntaje.Mala;
            if (porcentaje >= 30 && porcentaje <= 69)
                FiabResultados.Madurez = (int)Puntaje.Regular;
            if (porcentaje >= 70 && porcentaje <= 100)
                FiabResultados.Madurez = (int)Puntaje.Buena;
        }
        #endregion

        #region Mantenibilidad
        private void BarComentario_Scroll(object sender, EventArgs e)
        {
            int porcentaje = this.BarComentario.Value;
            if (porcentaje >= 0 && porcentaje <= 14)
                MantResultados.Analizabilidad = (int)Puntaje.Mala;
            if (porcentaje >= 15 && porcentaje <= 29)
                MantResultados.Analizabilidad = (int)Puntaje.Regular;
            if (porcentaje >= 30 && porcentaje <= 100)
                MantResultados.Analizabilidad = (int)Puntaje.Buena;
        }

        private void MantB1_Click(object sender, EventArgs e) => MantResultados.Cambiabilidad = (int)Puntaje.Mala;
        private void MantB2_Click(object sender, EventArgs e) => MantResultados.Cambiabilidad = (int)Puntaje.Regular;
        private void MantB3_Click(object sender, EventArgs e) => MantResultados.Cambiabilidad = (int)Puntaje.Buena;

        private void MantC1_Click(object sender, EventArgs e) => MantResultados.Estabilidad = (int)Puntaje.Mala;
        private void MantC2_Click(object sender, EventArgs e) => MantResultados.Estabilidad = (int)Puntaje.Regular;
        private void MantC3_Click(object sender, EventArgs e) => MantResultados.Estabilidad = (int)Puntaje.Buena;
        #endregion

        #region Usabilidad
        private void UsabA1_Click(object sender, EventArgs e) => UsabResultados.Entendibilidad = (int)Puntaje.Mala;
        private void UsabA2_Click(object sender, EventArgs e) => UsabResultados.Entendibilidad = (int)Puntaje.Regular;
        private void UsabA3_Click(object sender, EventArgs e) => UsabResultados.Entendibilidad = (int)Puntaje.Buena;

        private void UsabB1_Click(object sender, EventArgs e) => UsabResultados.Operabilidad = (int)Puntaje.Mala;
        private void UsabB2_Click(object sender, EventArgs e) => UsabResultados.Operabilidad = (int)Puntaje.Regular;
        private void UsabB3_Click(object sender, EventArgs e) => UsabResultados.Operabilidad = (int)Puntaje.Buena;

        private void UsabC1_Click(object sender, EventArgs e) => UsabResultados.Atraccion = (int)Puntaje.Mala;
        private void UsabC2_Click(object sender, EventArgs e) => UsabResultados.Atraccion = (int)Puntaje.Regular;
        private void UsabC3_Click(object sender, EventArgs e) => UsabResultados.Atraccion = (int)Puntaje.Buena;
        #endregion

        #region Portabilidad
        private void PortaA1_Click(object sender, EventArgs e) => PortResultados.Adaptabilidad = (int)Puntaje.Mala;
        private void PortaA2_Click(object sender, EventArgs e) => PortResultados.Adaptabilidad = (int)Puntaje.Regular;
        private void PortaA3_Click(object sender, EventArgs e) => PortResultados.Adaptabilidad = (int)Puntaje.Buena;

        private void PortaB1_Click(object sender, EventArgs e) => PortResultados.Instalabilidad = (int)Puntaje.Mala;
        private void PortaB2_Click(object sender, EventArgs e) => PortResultados.Instalabilidad = (int)Puntaje.Regular;
        private void PortaB3_Click(object sender, EventArgs e) => PortResultados.Instalabilidad = (int)Puntaje.Buena;
        #endregion

        // Minimo requerido para considerar, es tener como mucho 1 Mala
        private bool Califica(int puntaje) => puntaje > (int)Puntaje.Mala + (int)Puntaje.Regular + (int)Puntaje.Regular;
    }

    public class Funcionabilidad
    {
        public int SeguridadAcceso { get; set; } = (int)Puntaje.Buena;
        public int Exactitud { get; set; } = (int)Puntaje.Buena;
        public int Adecuacion { get; set; } = (int)Puntaje.Mala;
        private const int MINIMO = 13;

        public int GetPuntaje()
        {
            int puntaje = this.SeguridadAcceso + this.Exactitud + this.Adecuacion;
            if (puntaje < MINIMO)
                throw new InvalidOperationException();
            return puntaje;
        }
    }

    public class Eficiencia
    {
        public int Recursos { get; set; } = (int)Puntaje.Buena;
        public int Comportamiento { get; set; } = (int)Puntaje.Buena;
        public int Funcionamiento { get; set; } = (int)Puntaje.Buena;
        private const int MINIMO = 8;

        public int GetPuntaje()
        {
            int puntaje = this.Recursos + this.Comportamiento + this.Funcionamiento;
            if (puntaje < MINIMO)
                throw new InvalidOperationException();
            return puntaje;
        }
    }

    public class Fiabilidad
    {
        public int Tolerancia { get; set; } = (int)Puntaje.Buena;
        public int Recuperacion { get; set; } = (int)Puntaje.Buena;
        public int Madurez { get; set; } = (int)Puntaje.Mala;
        private const int MINIMO = 13;

        public int GetPuntaje()
        {
            int puntaje = this.Tolerancia + this.Recuperacion + this.Madurez;
            if (puntaje < MINIMO)
                throw new InvalidOperationException();
            return puntaje;
        }
    }

    public class Mantenibilidad
    {
        public int Analizabilidad { get; set; } = (int)Puntaje.Mala;
        public int Cambiabilidad { get; set; } = (int)Puntaje.Buena;
        public int Estabilidad { get; set; } = (int)Puntaje.Buena;
        private const int MINIMO = 17;

        public int GetPuntaje()
        {
            int puntaje = this.Analizabilidad + this.Cambiabilidad + this.Estabilidad;
            if (puntaje < MINIMO)
                throw new InvalidOperationException();
            return puntaje;
        }
    }

    public class Usabilidad
    {
        public int Entendibilidad { get; set; } = (int)Puntaje.Buena;
        public int Operabilidad { get; set; } = (int)Puntaje.Buena;
        public int Atraccion { get; set; } = (int)Puntaje.Buena;
        private const int MINIMO = 17;

        public int GetPuntaje()
        {
            int puntaje = this.Entendibilidad + this.Operabilidad + this.Atraccion;
            if (puntaje < MINIMO)
                throw new InvalidOperationException();
            return puntaje;
        }
    }

    public class Portabilidad
    {
        public int Adaptabilidad { get; set; } = (int)Puntaje.Buena;
        public int Instalabilidad { get; set; } = (int)Puntaje.Buena;
        private const int MINIMO = 13;

        public int GetPuntaje()
        {
            int puntaje = this.Adaptabilidad + this.Instalabilidad;
            if (puntaje < MINIMO)
                throw new InvalidOperationException();
            return puntaje;
        }
    }

    public enum Puntaje
    {
        Mala = 3,
        Regular = 5,
        Buena = 8
    }

}
