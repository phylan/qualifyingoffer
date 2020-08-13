# qualifyingoffer
Questionnaire response application

## Live Version
To view a live version proceed to https://qualifyingoffer.onrender.com

## Running locally 
  1. Clone this repostiory
  2. Change working directory to /qo.web
  3. Run `yarn install`
  4. Run `yarn run serve`
  5. View at http://localhost:8080

## Highlights
  1. Clean, maintainable and testable architecture -- core application logic takes no dependencies
  2. Clean boundaries via use of the mediator pattern, command/query separation, and dependency injection
  3. Configurability of both scraping classes and offer rules via runtime config injection
  4. Maintainable, component-based Vue front end with Typescript API client 
  
## Supporting libraries
  1. HTML Scraping with [HTML Agility Pack](https://github.com/zzzprojects/html-agility-pack)
  2. Mediator pattern implementation with [MediatR](https://github.com/jbogard/MediatR)
  3. Open API document generation with [NSwag](https://github.com/RicoSuter/NSwag)
  4. Typescript client generation with [NSwag Studio](https://github.com/RicoSuter/NSwag/wiki/NSwagStudio)
  5. Utility-based CSS with [TailwindCSS](https://github.com/tailwindlabs/tailwindcss)
