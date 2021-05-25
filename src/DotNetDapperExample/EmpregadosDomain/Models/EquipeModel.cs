using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmpregadosDomain.Models
{
    [Table("Equipe")]
    public class EquipeModel 
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        public ICollection<FuncionarioModel> Integrantes { get; set; }
    }
}
