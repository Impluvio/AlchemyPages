namespace AlchemyPages.Services
{
    // Used only for notes:

    //To do: 
    // - add a log to the player knowledge page so that we can see changes made
    // - find out if the playerknowledge model actually needs refs to the player and ingredient classes. 
    // - add ability to edit the quality number to the admin/playerknowledge page
    // - add player page that shows them what does what.
    // - assure the await method is use with the above^
    // - Remove ingredient encounter model and table.
    // - introduce functionality to delete player, that enables us to delete all associated entries, so for example remove entries with that player name from the playerknowledge table.

    // - logic is not updating on "create ingredient page" - debug this. - <CHECK THIS>

    // - update the html form to form-select from for-control for type / elements / qualities 1,2 & 3 

    // - look at creating user / admin sort of interface -



    //--------------------------------------


    //General notes
    // - ICollection<ingredientEncounter> denotes the many to many relationship and helps navigate.
    // - check to see if ingredient ID works without changing name on the ingredients table. - done


    //--------------------------------------

    //STRETCH

    // - automate creation of unique database setup when you create a new alchemy book.
    // - Make it possible to delete the database with several checks in place.
    // - make a prettier version than the simple standard razor pages format.
    // - change the qualities to also display little icons


    //--------------------------------------

    // DONE

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
