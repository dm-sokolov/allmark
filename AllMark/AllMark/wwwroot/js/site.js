$(() => {
    setControlsSettings();
});


function setControlsSettings() {
    // открытие выпадашки комобокса по нажатию на поле, а не только на "треугольник"
    $('[data-role=combobox]').each(function() {
        var widget = $(this).getKendoComboBox();
        widget.input.focus(() => {
            widget.open();
            widget.input.select();
        });
        widget.input[0].setAttribute("autocomplete", "off");
    });

    $('[data-role=datepicker]').each(function () {
        var widget = $(this).getKendoDatePicker();
        $(widget.element).on('change', validateDateInput);
    });

    $('input[type=text]').focus(function() {
        var input = $(this);
        clearTimeout(input.data('selectTimeId'));
        const selectTimeId = setTimeout(() => { input.select(); });
        input.data('selectTimeId', selectTimeId);
    }).blur(clearTimeout($(this).data('selectTimeId')));

    $('input').focus(function() {
        $(this).select();
    });

    $('input[data-role=numerictextbox]').focus(function () {
        const input = $(this).select();
        if (input.value === '0') {
            input.value = '';
        }
    });
}

