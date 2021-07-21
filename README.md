# EmergentCodeChallenge
Code Challenge for Emergent Software

# Some things I thought about and would probably be asking
* The requirement is currently search by version.  Is searching by name or name and version not necessary?
* The list of software isn't very long - as the list grows, the current visual for results may not be the best fit.  What do we expect the growth rate to be?
* The requirement listed finding software greater than what was searched for.  The current logic will not return the item if it is exactly what was searched for.
* The requirement listed "simple website". The website created is simple and changing colors or altering the design slightly can and should be discussed to match color 
schemes or other client applications.
* The user friendliness of being able to deep link into a search is not currently supported.  This could be a nice feature and can be done with more time.

# Some thoughts on expansion in the future if necessary
* Adding a backing data store of some type
* Auto-search based on how the user's typing has slowed down
* Pagination of results (if the list grows to be too big)
* If more features are needed, consider moving to an API-first model to aid in any front-end framework additions (React, Vue.js, Angular, etc)
  * Note: This would also help if web and mobile or even desktop clients were needed.  For the current requirements, adding these were seen as unnecessary.
