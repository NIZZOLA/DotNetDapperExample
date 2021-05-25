using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmpregadosDomain.Models
{
    [Table("Funcionario")]
    public class FuncionarioModel 
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(18)]
        public string Cpf { get; set; }

        [MaxLength(18)]
        public string Rg { get; set; }

        public GenderTypeEnum Sexo { get; set; }
        public DateTime Nascimento { get; set; }

        // Auto-Relacionamento
        [ForeignKey("SuperiorImediato")]
        public int? SuperiorImediatoId { get; set; }
        public FuncionarioModel SuperiorImediato { get; set; }

        // Relacionamento Um para Um
        [ForeignKey("Time")]
        public int? TimeId { get; set; }
        public EquipeModel Time { get; set; }

        [ForeignKey("Cargo")]
        public int? CargoId { get; set; }
        public CargoModel Cargo { get; set; }

        // Um para muitos
        public ICollection<FuncionarioModel>  Subordinados { get; set; }
    }
}
