using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;

namespace AlchemyPages.Services
{
    // Used only for notes:

    //To do: 
    // - add a back button to the add / edit player knowledge pages
    // - add player page that shows them what does what.

    // - introduce functionality to delete player, that enables us to delete all associated entries, so for example remove entries with that player name from the playerknowledge table.
    // - logic is not updating on "create ingredient page" - debug this. - <CHECK THIS>
    // - update the html form to form-select from form-control for type / elements / qualities 1,2 & 3 
    // - look at creating user / admin sort of interface.
    // 

    // Player View:
    // Player selects their craftbook - DONE
    // we need to get that players name, the ingredient & the knowledge. - DONE 
    // we need to display the player name - then a list of the ingredients that they know. - DONE
    // and do a foreach to display the properties associated with the ingredient which depends on the qualities they know. 



    //--------------------------------------


    //General notes
    // - ICollection<ingredientEncounter> denotes the many to many relationship and helps navigate.
    // - check to see if ingredient ID works without changing name on the ingredients table. - done


    //--------------------------------------

    //STRETCH

    // - automate creation of unique database setup when you create a new alchemy book.
    // - Make it possible to clear the database with several checks in place.
    // - make a prettier version than the simple standard razor pages format.
    // - change the qualities to also display little icons


    //--------------------------------------

    // DONE

    //         21/05/25
    // - fix delete on update playerbook
    // - fixed cancel button on same page
    // - assure the await method is use with the above^


    //         19/05/25
    // - add a log to the player knowledge page so that we can see changes made - not needed now.
    // - add a check to ensure that an ingredient has not been already added to the players book to prevent crashing.
    // - add ability to edit the quality number to the admin/playerknowledge page
    // - Remove ingredient encounter model and table. - Resolved (decoupled from code)

    //         17/05/25
    // - added logic to pull link players name / id with ingredient name / id and qualites, this doesn't work yet, so we need to update it.


    //         15/05/25
    // - add logic for delete process in both the ingredients section and the player sections.
    // - Delete needs to drop entry from table. Check ingredient & players.
    // - at present onget is not async across pages - update so that it is - this better for sql based applications when querying the database - update similar methods to comply with this.

    //         11/05/25
    // - update ingredient edit page. - Done

    //         07/05/25
    // - drop the player table i created via query - DONE
    // - change permissions so i can do the above^ - DONE
    // - migration has been added, we need to update database once the player table has been removed - DONE 
    // - create logic to save and display images from c drive - DONE



}
