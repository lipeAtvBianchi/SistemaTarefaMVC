namespace sistemaAgendamento.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool Status { get; set; }
        
    }
}