namespace interbank_app.Models
{
    public class CustomResponse
    {
        public CustomResponse(bool error = false)
        {
            if (!error)
            {
                this.Code = "Ok";
                this.Message = "La consula se realizo correctamnente";
            }
            else
            {
                this.Code = "Error";
                this.Message = "Lo sentimos, ocurrio un error";
            }

        }
        public string Code { get; set; }
        public string Message { get; set; }
        public bool Data { get; set; }
    }
}
