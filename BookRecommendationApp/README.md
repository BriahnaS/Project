
# Book Recommendation Tool/App

- Progressively narrow down book recommendations based on user input on preferred Genres, Tropes, and Subplots, and display a list of books at the end with descriptions
- Provide option to also randomly generate a book recommendation
- Implement AI enhancements for Similarity and Search functions

# Language, Framework, and App Type
* C#
* .Net 10 
* .NET MAUI Application

# Custom Data Types
## Classes 
### Parent
- `Book`

### Children
- `Audiobook`
- `Ebook` 
- `Physical` 

## Methods
- `Genre selection`
- `Trope/Subplot selection`
- `API calls` to:
    - `Pull List of Recommendations`
    - `Generate Random Book`
- `Next`
- `Start Over`

## Properties
Book
- `Genre` 
- `Author` 
- `Publisher` 
- `Edition` 
- `Subplot`

AudioBook
- `Narrator/s Names` 
- `Single narrator` (bool)
- `Duet Narration` (bool)
- `Dual Narration` (bool)
- `Graphic Audio` (bool)

Physical 
- `Type` *paperback/hardback* 


# Preliminary Solution Structure
## Primary Data Structure
- List of Objects of type book 
- Each user selection will implement LINQ filtering 

## Flow
- Welcome and provide options 
    - Build-A-Rec
    - Random

### Build a Rec Selected
- Select genres 
    - Selected choices are highlighted and allow user to deselect them
    - Either select "Find Your Books" or "Next"
- "Next" navigates to trope and subplot selection
    - Selected choices are highlighted and allow user to deselect them
    - Select "Find Your Books"
- "Find Your Books" calls the API with LINQ filtering based on the user's selections
    - Clicking on the book itself with pop up a card that displays the description of the book
- "Start Over" button brings user back to the welcome page

### Random Selected
- Navigate to another page with a flip card to display randomly pulled book from the database

# External Resources Required
- Self built relational database and API 

# AI Enhancement
- Build AI crawler to monitor publishers for new book data (release dates, titles, descriptions, etc.) which then runs the similarity method to determine if it would suit a user's interest
- Develop a similarity feature based on existing data
    - Utilize AI to connect similar tropes/subplots and enhance the similarity score
    - Run similarity feature when new book is added
    - Also, be able to use similarity service for semantic search 
- LLM Implementation
    - Utilize Azure OpenAI to determine tone, audience, etc. which can then be stored in SQL 

# Planned Development Time: ~12-20 hours