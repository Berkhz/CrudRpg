using Rpg.Src.@enum;

namespace crud_rpg.Src.Dto
{
    public class ItemMagicoDto
    {
        public string Nome { get; set; }
        public TipoItem TipoDoItem { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
    }
}
