using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmpregadosDomain.Models
{
    [Table("Cargo")]
    // classe usada para cargos
    public class CargoModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string NomeDoCargo { get; set; }

        public bool IsManager { get; set; }

        public ICollection<FuncionarioModel> Funcionarios { get; set; }
    }
}
