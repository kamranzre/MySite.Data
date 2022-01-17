function refreshGrid(targetId) {
    if ($(targetId)[0]) {
        $(targetId).data('kendoGrid').dataSource.read();
        $(targetId).data('kendoGrid').refresh();
        debugger
        counter = 1;
    }
}


function ShowAlertToast(type, ttl, message) {
    var shortCutFunction = '';
    var toastCount = 0;
    if (type == 0) {
        shortCutFunction += 'success';
    } else if (type == 1) {
        shortCutFunction += 'error';
    } else if (type == 2) {
        shortCutFunction += 'warning';
    } else if (type == 3) {
        shortCutFunction += 'info';
    }
    //var shortCutFunction = $("#toastTypeGroup input:checked").val();
    var msg = message;
    var title = ttl;
    var $showDuration = '1000';
    var $hideDuration = '1000';
    var $timeOut = '5000';
    var $extendedTimeOut = '1000';
    var $showEasing = 'swing';
    var $hideEasing = 'linear';
    var $showMethod = 'fadeIn';
    var $hideMethod = 'fadeOut';
    var toastIndex = toastCount++;

    toastr.options = {
        closeButton: true, // $('#closeButton').prop('checked'),
        debug: false, // $('#debugInfo').prop('checked'),
        positionClass: 'toast-bottom-left',// $('#positionGroup input:checked').val() || 'toast-top-right',
        onclick: null
    };


    //if ($showDuration.val().length)
    {
        toastr.options.showDuration = $showDuration;
    }

    //if ($hideDuration.val().length)
    {
        toastr.options.hideDuration = $hideDuration;
    }

    //if ($timeOut.val().length)
    {
        toastr.options.timeOut = $timeOut;
    }

    //if ($extendedTimeOut.val().length)
    {
        toastr.options.extendedTimeOut = $extendedTimeOut;
    }

    //if ($showEasing.val().length) 
    {
        toastr.options.showEasing = $showEasing;
    }

    //if ($hideEasing.val().length)
    {
        toastr.options.hideEasing = $hideEasing;
    }

    //if ($showMethod.val().length) 
    {
        toastr.options.showMethod = $showMethod;
    }

    //if ($hideMethod.val().length)
    {
        toastr.options.hideMethod = $hideMethod;
    }


    $("#toastrOptions").text("Command: toastr[" + shortCutFunction + "](\"" + msg + (title ? "\", \"" + title : '') + "\")\n\ntoastr.options = " + JSON.stringify(toastr.options, null, 2));

    var $toast = toastr[shortCutFunction](msg, title); // Wire up an event handler to a button in the toast, if it exists
    $toastlast = $toast;
}
