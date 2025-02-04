namespace ListaTarefasAPI.Models
{
    public class Tarefa
    {
        public int Tarefaid { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
        public int Tipotarefaid { get; set; }
        public Tipotarefa? Tipotarefa { get; set; }
    }
}
