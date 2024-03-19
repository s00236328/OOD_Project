using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Windows.Input;
using Apex.MVVM;

namespace wpf_solitare
{


    /// Says what the card is and its properties, on playing field faced up etc

    public class PlayingCard : ViewModel
    {
        public CardType CardType { get; set; }
     
        public CardSuit Suit
        {
            get
            {
                
                int enumVal = (int)CardType;
                if (enumVal < 13)
                    return CardSuit.Hearts;
                if (enumVal < 26)
                    return CardSuit.Diamonds;
                if (enumVal < 39)
                    return CardSuit.Clubs;
                return CardSuit.Spades;
            }
        }
        public int Value
        {
            get
            {
                //  The CardType enum has 13 cards in each suit.
                return ((int)CardType) % 13;
            }
        }

        /// <summary>
        /// Gets the card colour.
        /// </summary>
        /// <value>The card colour.</value>
        public CardColour Colour
        {
            get
            {
                // The first two suits in the CardType
                // enum are red, the last two are black.
                return ((int)CardType) < 26 ?
                         CardColour.Red : CardColour.Black;
            }
        }
        private NotifyingProperty IsFaceDownProperty =
  new NotifyingProperty("IsFaceDown", typeof(bool), false);

        /// <summary>
        /// Gets or sets a value indicating whether this instance is face down.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is face down;
        ///     otherwise, <c>false</c>.
        /// </value>
        public bool IsFaceDown
        {
            get { return (bool)GetValue(IsFaceDownProperty); }
            set { SetValue(IsFaceDownProperty, value); }
        }

        /// <summary>
        /// The IsPlayable notifying property.
        /// </summary>
        private NotifyingProperty IsPlayableProperty =
          new NotifyingProperty("IsPlayable", typeof(bool), false);

        /// <summary>
        /// Gets or sets a value indicating whether this instance is playable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance
        ///    is playable; otherwise, <c>false</c>.
        /// </value>
        public bool IsPlayable
        {
            get { return (bool)GetValue(IsPlayableProperty); }
            set { SetValue(IsPlayableProperty, value); }
        }

        /// <summary>
        /// The FaceDown offset property.
        /// </summary>
        private NotifyingProperty FaceDownOffsetProperty =
          new NotifyingProperty("FaceDownOffset", typeof(double), default(double));

        /// <summary>
        /// Gets or sets the face down offset.
        /// </summary>
        /// <value>The face down offset.</value>
        public double FaceDownOffset
        {
            get { return (double)GetValue(FaceDownOffsetProperty); }
            set { SetValue(FaceDownOffsetProperty, value); }
        }

        /// <summary>
        /// The FaceUp offset property.
        /// </summary>
        private NotifyingProperty FaceUpOffsetProperty =
                new NotifyingProperty("FaceUpOffset",
                typeof(double), default(double));

        /// <summary>
        /// Gets or sets the face up offset.
        /// </summary>
        /// <value>The face up offset.</value>
        public double FaceUpOffset
        {
            get { return (double)GetValue(FaceUpOffsetProperty); }
            set { SetValue(FaceUpOffsetProperty, value); }
        }
    }
}