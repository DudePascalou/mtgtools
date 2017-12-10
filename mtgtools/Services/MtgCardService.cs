﻿using mtgtools.Models;
using mtgtools.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace mtgtools.Services
{
    public class MtgCardService
    {
        private ICollection<Set> _sets;
        private IDictionary<string, Card> _cardsByName;

        public MtgCardService()
        {
            _cardsByName = new Dictionary<string, Card>();

            var filePath = @"C:\Users\PC\Documents\GitHub\mtgtools\mtgtools\Data\LightSets-x.json"; // TODO : find another way to load cards...
            var jsonFileContent = File.ReadAllText(filePath);
            dynamic dynSets = JsonConvert.DeserializeObject(jsonFileContent);
            IDictionary<string, JToken> jsonSets = dynSets;

            _sets = new List<Set>(jsonSets.Keys.Count);
            foreach (var jsonSet in jsonSets)
            {
                var set = JsonConvert.DeserializeObject<Set>(jsonSet.Value.ToString());
                if (set != null)
                {
                    _sets.Add(set);
                    foreach (var card in set.Cards)
                    {
                        if (!_cardsByName.ContainsKey(card.Name))
                        {
                            _cardsByName.Add(card.Name, card);
                        }
                    }
                }
            }
        }

        public Card FindByName(string name)
        {
            if (_cardsByName.ContainsKey(name))
            {
                return _cardsByName[name];
            }
            else if (name.Contains(Resources.AftermathSeparator))
            {
                // TODO : manage aftermath cards...
                return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Parse a deck list into a <see cref="Deck"/>.
        /// Expected deck list is a set of lines, each composed of the count and the card name.
        /// Lines starting with "//" are ignored.
        /// Lines starting with "SB" are added to sideboard.
        /// </summary>
        /// <param name="deckList">Card names and count list.</param>
        /// <returns>The <see cref="Deck"/>.</returns>
        /// <example>
        /// // Planeswalkers
        /// 1 Nissa, Steward of Elements
        /// // Creatures
        /// 1 Elvish Mystic
        /// </example>
        public Deck ParseDeckList(string name, Format format, string deckList)
        {
            var deck = new Deck(name, format);

            var nbAndNames = deckList.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var nbAndName in nbAndNames)
            {
                if (nbAndName.StartsWith(Resources.CommentPrefix)) continue;

                var toSideboard = nbAndName.StartsWith(Resources.SideboardPrefix);
                var firstSpaceIndex = nbAndName.IndexOf(' ');
                var secondSpaceIndex = nbAndName.IndexOf(' ', firstSpaceIndex + 1);

                if (firstSpaceIndex == -1 && secondSpaceIndex == -1) { continue; }

                // Parse card count (main or sideboard) :
                var cardCount = toSideboard
                    ? int.Parse(nbAndName.Substring(firstSpaceIndex + 1, secondSpaceIndex - firstSpaceIndex))
                    : int.Parse(nbAndName.Substring(0, firstSpaceIndex));
                // Parse card name (main or sideboard) :
                var cardName = toSideboard
                    ? nbAndName.Substring(secondSpaceIndex + 1, nbAndName.Length - secondSpaceIndex - 1)
                    : nbAndName.Substring(firstSpaceIndex + 1, nbAndName.Length - firstSpaceIndex - 1);

                var card = FindByName(cardName);
                if (card != null)
                {
                    deck.Add(card, cardCount, toSideboard);
                }
            }

            return deck;
        }

        #region Static methods

        public static Card ParseCard(string cardJson)
        {
            return JsonConvert.DeserializeObject<Card>(cardJson);
        }

        #endregion
    }
}