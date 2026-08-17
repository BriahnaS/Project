
# Book Recommendation Tool/App

- Progressively narrow down book recommendations based on user input on preferred Genres, Tropes, and Subplots, and display a list of books at the end (and blurbs, if time permits)
- Provide option to also randomly generate a book recommendation
- Transform to Final Project (either add more features, or adapt an interactive, visually appealing user interface)
# Language, Framework, and App Type
* C#
* .Net 10 
* Console App

# Custom Data Types
## Classes 
### Parent
- `Book`

### Children
- `Audiobook`
- `Ebook` 
- `Physical` 

## Methods
- `Display menu (switches)`
- `Get User Input`
- `Sort/Refine List (LINQ filtering)`
- `Search/Pull List of Recommendations`
- `Generate Random Book`
## Properties
Book
- `Genre` (enum)
- `Author` (string)
- `Publisher` (string)
- `Special Edition/Bonus Content` (bool)
- `Subplot` (string)

AudioBook
- `Narrator/s Names` (string)
- `Single narrator` (bool)
- `Duet Narration` (bool)
- `Dual Narration` (bool)
- `Graphic Audio` (bool)

Physical 
- `Type` *paperback/hardback* (enum)


# Preliminary Solution Structure
## Primary Data Structure
- List of Objects of type book (maybe separate lists depending on type of book i.e. child classes)
- Each user selection will implement LINQ filtering 

## Flow
- Welcome and provide options (Build a Rec or Random)
- Prompt for user input
- Read input and proceed accordingly
    - If Random is selected => Find a random book in the data and display
    - If Build a Rec is selected => display genre menu (loop until user selects "Find Books" option)
- Provide option to exit or start over

### Build a Rec Selected
- Prompt for input
- Read input and refine list of data behind the scenes
- Display menu for genre specific subplots or tropes, or provide option to see list at the current level
- Prompt for input 
- Read input and further refine
- Etc.

# External Resources Required
- N/A - book information will be hardcoded, unless Database or API is readily available

# Planned Development Time: ~8-12 hours