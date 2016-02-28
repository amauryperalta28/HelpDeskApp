var TicketJs = function () {

    $("input").focus(function () {
        $(this).parents("div.form-group").removeClass("has-error");
    });
    $("textarea").focus(function () {
        $(this).parents("div.form-group").removeClass("has-error");
    });
    $("select").click(function () {
        $(this).parents("div.form-group").removeClass("has-error");
    });

    $("input").click(function () {
        $(this).parents("div.form-group").removeClass("has-error");
    });

    return {
        validateForm: function () {
            var result = true;
            var stringError = "<div><div>";
            var ul = "<ul></ul>";
            $.each($('.required'), function (index, obj) {
                var $obj = $(obj);

                if ($obj.val().length == 0) {

                    ul = $(ul).append("<li>" + $obj.data('requirederror') + "</li>");
                    $obj.parents("div.form-group").addClass("has-error");
                    result = false;
                }
                
            });

            $.each($('select:visible'), function (index, obj) {
                var $obj = $(obj);
                if ($obj.val() == -1) {
                    ul = $(ul).append("<li>" + $obj.data('message') + "</li>");
                    $obj.parents("div.form-group").addClass("has-error");
                    result = false;
                }
            });

            if (!result) {
                stringError = $(stringError).append(ul);
                CreateGritter('El formulario tiene los siguientes errores', stringError.html(), 'gritter-error gritter-danger', false);
            } else {
                BlockControl(".page-content");
            }


            return result;
        },
        dataController: function (data) {

            if (data.success) {
                CreateGritter(data.title, '<p>' + data.message + '</p>', 'gritter-success', true);
                if (!data.edit)
                { clearForm.click(); }

            }

            else {

                CreateGritter(data.title, '<p>' + data.message + '</p>', 'gritter-error', false);
            }

           UnBlockControl(".page-content");

        }
    }
    
   
}();