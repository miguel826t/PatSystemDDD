$(document).ready(function () {
		
    $.getJSON('/json/CursosTecnico.json', function (data) {

        var items = [];
        var options = '<option value="">Modalidade</option>';	

        $.each(data, function (key, val) {
            options += '<option value="' + val.modalidade + '">' + val.modalidade + '</option>';
        });					
        $("#ModalidadeTecnico").html(options);				
        
        $("#ModalidadeTecnico").change(function () {				
        
            var options_nome= '';
            var str = "";					
            
            $("#ModalidadeTecnico option:selected").each(function () {
                str += $(this).text();
            });
            
            $.each(data, function (key, val) {
                if(val.modalidade == str) {							
                    $.each(val.nome, function (key_nome, val_nome) {
                        options_nome += '<option value="' + val_nome + '">' + val_nome + '</option>';
                    });							
                }
            });

            $("#NomeCursoTecnico").html(options_nome);
            
        }).change();		
    
    });

});