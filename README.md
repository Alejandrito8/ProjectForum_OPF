# Documentation/Readme:

## Description of our project and the technology we use: 
This project is built using the various methods we have learned from object-oriented programming. The purpose of our project is to build a forum where individuals can share their thoughts and interests. We chose to create a homepage with a headline and image for styling purposes and for the website itself. We decided to create two admin pages, one for admin settings and one for the admin page. Admin settings contain the posts and comments created in the forum by users, as well as a delete function. We also chose to have an admin page for functions that adjust the roles of users who create accounts, and also to be able to delete an account and roles.

Then we specifically chose the categories in the forum, comstanding of big topics such as economics, sports, foods & drinks, science and also a field named other for posts not suited for the other categories. When you click on a specific category, you are taken to a forum page for that specific category where you can create posts and edit them, as well as comment and reply to comments and like posts.

We chose to create a forum component that gets redirected to with the press of the button from one of the categories. Logged-in users can create, edit, and delete their own posts in the forum. All posts are listed with title, content, author, and publication date. Edit and delete buttons are only visible to the post owner. It also integrates a CommentsAndLikes child-component for interactions.

CommentsAndLikes have been built with ASP.NET Core and Entity Framework Core, which handles comments, replies to comments, and likes for posts in our forum. The purpose of the component is to give users the ability to interact with posts by commenting, replying, and liking them in real time.

The technology we have used includes:
Languages and Frameworks: C#, .NET, Blazor, SQL
Database: SQLite
ASP.NET Core Identity
Entity Framework Core
Bootstrap: CSS
Authorization & Authentication


------------------------------------------------------------------------------------------------------------------------------------------------------
### Tre användarscenarion utifrån strukturen:
| ID  | Kategori    | Scenario    | Teststeg | Förv. Resultat    |   Faktiskt Resultat  | Status | Åtgärdsförslag  |                     
------------------------------------------------------------------------------------------------------------------------------------------------------
| 1 | 
| Inloggning |
| Användare loggar in med giltiga uppgifter |
| 1. Navigera till login - 2. Skriv korrekt information - e-post och lösenord  - 3. Klicka på "Logga in" och skickas till hemsidan |
| Användaren loggas in och omdirigeras till hemsidan. Vid felaktiga uppgifter får användaren ett felmeddelande. |
| Användare loggas in och omdirigeras korrekt |
| Pass |
| Ingen åtgärd behövs, funktionen fungerar som förväntat. Säkerställ att felmeddelande visas vid inloggningsfel. |

------------------------------------------------------------------------------------------------------------------------------------------------------
| 2 |
| Admin-behörighet |
| Admin har en settings page för att se alla kommentarer och inlägg |
| 1. Logga in som admin  - 2. Navigera till admin settings page  - 3. Kontrollera att alla kommentarer och inlägg visas samt testa radering |
| Admin ska kunna se och radera alla kommentarer och inlägg, oavsett vem som postat dem. |
| Alla kommentarer och inlägg visas och kan raderas |
| Pass |
| Säkerställ att endast administratörer har tillgång till denna funktion. |

------------------------------------------------------------------------------------------------------------------------------------------------------
| 3 |
| Användar-behörighet |
| Användaren ska kunna ta bort sin kommentar |
| 1. Logga in som användare  - 2. Navigera till forum page, välj ämne och hitta egna kommentarer  - 3. Klicka på "Ta bort" för att radera |
| Användaren kan ta bort sina egna kommentarer från både forum och databas. |
| Kommentar tas bort korrekt |
| Pass |
| Säkerställ att endast användaren själv eller en admin kan ta bort kommentaren. |
