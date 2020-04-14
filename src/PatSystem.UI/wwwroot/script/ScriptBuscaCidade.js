$(document).ready(function () {

    $.getJSON('/json/estados_cidades.json', function (data) {

        var items = [];
        var options = '<option value="">estado</option>';

        $.each(data, function (key, val) {
            options += '<option value="' + val.sigla + '">' + val.sigla + '</option>';
        });
        $("#estados").html(options);

        $("#estados").change(function () {

            var options_cidades = '';
            var str = "";

            $("#estados option:selected").each(function () {
                str += $(this).text();
            });

            $.each(data, function (key, val) {
                if (val.sigla == str) {
                    $.each(val.cidades, function (key_city, val_city) {
                        options_cidades += '<option value="' + val_city + '">' + val_city + '</option>';
                    });
                }
            });

            $("#cidades").html(options_cidades);

        }).change();

    });

});