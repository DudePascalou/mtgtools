using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgtools.Models
{
    interface ICardSet
    {
        ObservableCollection<Card> Cards { get; set; }
        bool HasLand { get; }

        IEnumerable<Card> Artifacts();
        IEnumerable<Card> Creatures();
        IEnumerable<Card> Enchantments();
        IEnumerable<Card> Instants();
        IEnumerable<Card> Lands();
        IEnumerable<Card> Planeswalkers();
        IEnumerable<Card> Sorceries();
    }
}
