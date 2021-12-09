using System.Data.Entity;

namespace gladiaddi
{


    partial class Gladiators
    {

        DbSet<Gladiator> GladiStorage { get; set; }
    }
}
