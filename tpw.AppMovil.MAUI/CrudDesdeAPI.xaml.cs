using tpw.APIConsumer;
using tpw.Entidades;

namespace tpw.AppMovil.MAUI;


public partial class CrudDesdeAPI : ContentPage
{
    private string apiUrl = "https://tpwproyecto.azurewebsites.net/api/Generos";

    public CrudDesdeAPI()
	{
		InitializeComponent();
	}

    private void cmdNuevo_Clicked(object sender, EventArgs e)
    {
        try
        {
            var datos = new Genero
            {
                Id = 0,
                Descripcion = txtDescripcion.Text
            };

            datos = Crud<Genero>.Create(apiUrl, datos);
            txtIdGenero.Text = datos.Id.ToString();
        }
        catch (Exception ex)
        {
            this.DisplayAlert("ATENCION !!", ex.Message, "CANCELAR");
        }
    }

    private void cmdActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var datos = new Genero
            {
                Id = int.Parse(txtIdGenero.Text),
                Descripcion = txtDescripcion.Text
            };

            var result = Crud<Genero>.Update(apiUrl, datos.Id, datos);
            if (result)
                this.DisplayAlert("OK", "Registro actualziado", "CONTINUAR");
            else
                this.DisplayAlert("ERROR", "Registro NO se pudo actualizar", "CONTINUAR");
        }
        catch (Exception ex)
        {
            this.DisplayAlert("ATENCION !!", "Registro no encontrado", "CANCELAR");
        }
    }

    private void cmdConsultar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var datos = Crud<Genero>.Read_ById(apiUrl, int.Parse(txtIdGenero.Text));
            txtDescripcion.Text = datos.Descripcion;
        }
        catch (Exception ex)
        {
            this.DisplayAlert("ATENCION !!", "Registro no encontrado", "CANCELAR");
        }
    }

    private void cmdBorrar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Crud<Genero>.Delete(apiUrl, int.Parse(txtIdGenero.Text));
            txtIdGenero.Text = "";
            txtDescripcion.Text = "";
        }
        catch (Exception ex)
        {
            this.DisplayAlert("ATENCION !!", "Registro no encontrado", "CANCELAR");
        }
    }
}