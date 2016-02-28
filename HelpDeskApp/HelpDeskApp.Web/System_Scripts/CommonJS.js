function BlockScreen() {
    $.blockUI({
        message: '<h2><i class="fa fa-spinner fa-spin vd_green"></i></h2>',
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff',
            overlayCSS: { backgroundColor: '#FFF' }
        }
    });
}

function UnBlockScreen() {
    $.growlUI('', '');
}
function ValidateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function BlockControl(control) {
    $(control).block({
        message: '<h2><i class="fa fa-spinner fa-spin vd_green"></i></h2>',
            css: { 
                border: 'none', 
                padding: '15px', 
                background: 'none',
            },
            overlayCSS: { backgroundColor: '#FFF' }
        
    });
}
function UnBlockControl(control) {
    $(control).unblock();
}

function CreateGritter(title, text, classes, sticky) {
    var time = 0;
    if (!sticky) {
        time  = 4000
    }
    $.gritter.add({
        title: title,
        text: text,

        sticky: sticky,
        time: time,
        class_name: classes
    });
}