$.ajaxSetup({
    error: function (xhr, textStatus, errorThrown) {
        
        //make sure this isn't caused by navigating away from the page by checking the xhr readyState
        if (xhr.readyState == 4) {

            switch (xhr.status) {
                case 401:
                case 403:
                    
                    // take them to the login but hang on to their current url
                    //calling reload does this by leveraging the rest of our framework automagically!
                    //window.location.reload(true);
                    window.location.reload(true);
                    break;
                default:
                    //bootbox.alert('<div class="text-center"><h2>An error was encountered</h2><h3>Sorry, an error has occurred.  The system administrators have been notified.</h3></div>');
                    break;
            }
        }
    }
});