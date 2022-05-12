function printDeckOfCards(arr) {
    let result = [];

    try {
        for (let card of arr) {
            let face = card.slice(0, card.length - 1);
            let suit = card.slice(card.length - 1);
    
            result.push(createCard(face, suit).toString());
        }

        console.log(result.join(' '));
    } catch (er) {
        console.log(er.message);
    }

    function createCard(face, suit) {
        let validInput = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

        let suits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663'
        }

        if (!validInput.includes(face) || !Object.keys(suits).includes(suit)) {
            throw new Error(`Invalid card: ${face}${suit}`);
        }

        return {
            face,
            suit: suits[suit],
            toString: function () {
                return `${this.face}${this.suit}`;
            }
        }
    }
}  