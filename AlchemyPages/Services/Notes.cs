namespace AlchemyPages.Services
{
    // Used only for notes:

    //To do: 

    // - Delete needs to drop entry from table.

    // - Create Union between player table and encounters table, OR code solution to create seperate pages for each created player, to display encounters table - show this in Player View.
    // - Alter index to show this. 
    // - update migration. 



    // - logic is not updating on "create ingredient page" - debug this. - <CHECK THIS>
    // - update the html form to form-select from for-control for type / elements / qualities 1,2 & 3

    // - look at creating user / admin sort of interface -
    // - add logic for delete process in both the ingredients section and the player sections.


    //--------------------------------------


    //General notes
    // - ICollection<ingredientEncounter> denotes the many to many relationship and helps navigate.
    // - check to see if ingredient ID works without changing name on the ingredients table. - done


    //--------------------------------------

    //STRETCH

    // - automate creation of unique database setup when you create a new alchemy book.
    // - Make it possible to delete the database with several checks in place.
    // - make a prettier version than the simple standard razor pages format.


    //--------------------------------------

    // Done

    //         11/05/25
    // - update ingredient edit page. - Done

    //         07/05/25
    // - drop the player table i created via query - DONE
    // - change permissions so i can do the above^ - DONE
    // - migration has been added, we need to update database once the player table has been removed - DONE 
    // - create logic to save and display images from c drive - DONE


}
