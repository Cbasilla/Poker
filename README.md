# Poker
poker libraries made in c sharp

## Getting Started

 Clone git: 
  * https://github.com/Cbasilla/Poker
 
 
 
### Prerequisites

Install :
 * [Visual Studio](https://visualstudio.microsoft.com/vs/community/) - The ASP.NET core Web Application

### Assumptions
 * 6 poker hands that I implement: RoyalFlush, FourOfAKind, FullHouse, StraightFlush, Flush, Straight
 * Using Traditional High Poker Hand Ranks [Poker Rules](https://www.contrib.andrew.cmu.edu/~gc00/reviews/pokerrules).
 * Only evaluated cards/hand based on Rank (1 is lowest, Ace is
highest). Suit doesn’t matter.

## Running the tests

  Use [Visual Studio Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019) to run all the unit test in the solution.

``Note: When using the restlet client you can use the json files included in the git.You can also use the Swagger Ui in testing just run the project and after that access https://localhost:5001/swagger/index.html``
* [Check Poker When Valid Cards Returns Poker Winner -RoyalFlush, FourOfAKind, FullHouse](https://github.com/Cbasilla/Poker/blob/master/checkPoker_WhenValidCards_ReturnsPokerWinner_RoyalFlush_FourOfAKind_FullHouse.json) , 
* [Check Poker When Valid Cards Returns Poker Winner -StraightFlush, Flush, Straight](https://github.com/Cbasilla/Poker/blob/master/checkPoker_WhenValidCards_ReturnsPokerWinner_StraightFlush_Flush_Straight.json) , 
* [Poker Restlet Client Json File](https://github.com/Cbasilla/Poker/blob/master/https://github.com/Cbasilla/Poker/blob/master/Poker.json.json)
* [Restlet Client Screenshot](https://gyazo.com/4cf663f61684640925c32d59211292a5)
* [Microsoft Screenshot of Unit test](https://gyazo.com/67aef0a96f87d4a0675c47ca2aff76a7)
* [Swagger UI Screenshot](https://gyazo.com/72d71017db03d5884820758dd1985b80)

## Built With

* [Microsoft Visual Studio](https://visualstudio.microsoft.com/vs/) - The ASP.NET core Web Application used
* [SourceTree](https://www.sourcetreeapp.com/) - Git Client for Git repositories
* [Restlet Client](https://chrome.google.com/webstore/detail/talend-api-tester-free-ed/aejoelaoggembcahagimdiliamlcdmfm?hl=en) - Used to send request to rest API.

## Authors

* **Crisia Ann Basilla** - *Initial work* - [Poker](https://github.com/Cbasilla/Poker)

See also the list of [contributors](https://github.com/Cbasilla/Poker/contributors) who participated in this project.

## Acknowledgments
### Inspiration
*  [Nick Chapsas](https://github.com/Elfocrash) - [AspNetCoreTutorial](https://github.com/Elfocrash/Youtube.AspNetCoreTutorial)
*  [asathkumara](https://github.com/asathkumara) - [CSharp-Poker-Game](https://github.com/asathkumara/CSharp-Poker-Game)
