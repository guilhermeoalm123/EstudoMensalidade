var _$mapIndexConfig = {
    table: {
        id: '#tableEmpresas',
        dtButtons: '.dt-buttons',
        obj: null,
        onRender: {
            _detalhe: function (data, type, row, meta) {
                var htmlRender = '';

                htmlRender += '<i class="fa fa-fw fa-building" data-toggle="tooltip" title="Nome"></i> <strong> ' + row.razaoSocial + '</strong> <br /> ';
                htmlRender += '<i class="fa fa-fw fa-id-card" data-toggle="tooltip" title="CNPJ"></i> ' + row.cnpj + ' <br /> ';

                if (row.dataAbertura)
                    htmlRender += '<i class="fa fa-fw fa-calendar" data-toggle="tooltip" title="Iniciada"></i> ' + row.dataAbertura + '<br /> ';

                return htmlRender;
            },
            _situacao: function (data, type, row, meta) {
                if (row._Situacao)
                    return '<span class="badge badge-success">ATIVO</span>';
                else
                    return '<span class="badge badge-danger">INATIVO</span>';
            },
            _editar: function (data, type, row, meta) {
                let htmlRender = '';

                htmlRender += '<a class="btn btn-sm btn-warning" data-id="' + row.id + '" data-toggle="tooltip" title="Editar" onclick="_$mapIndexConfig.actions.redirectToEdit($(this))"><i class="fa fa-fw fa-edit"></i></a> ';

                htmlRender += '<a class="btn btn-sm btn-danger" data-id="' + row.id + '" data-toggle="tooltip" title="Deletar" onclick="_$mapIndexConfig.actions.openModalDelete($(this))"><i class="fa fa-fw fa-trash"></i></a> ';

                return htmlRender;
            }
        },
        draw: function () {
            _$mapIndexConfig.table.obj = this;
            $(_$mapIndexConfig.table.id).DataTable().columns.adjust();
        },
        reload: function () {
            $(_$mapIndexConfig.table.id).DataTable().ajax.reload();
        },
        initComplete: function (e, settings, json) {
            if (json !== undefined) {
                $(_$mapIndexConfig.table.dtButtons).append($(_$mapIndexConfig.botoes.btnCreate).detach());
                $(_$mapIndexConfig.table.id + "_btn").addClass("float-right pl-1");
                $(_$mapIndexConfig.botoes.btnCreate).removeClass('d-none')
            }
        }
    },
    botoes: {
        btnCreate: '#btnCreate'
    },
    actions: {
        redirectToEdit: function (obj) {
            var id = $(obj).data('id');
            window.location.href = _$mapIndexConfig.urls.get(1) + '?id=' + id;
        },
        openModalDelete: function (obj) {
            var id = $(obj).data('id');
            openModalDelete(id, _$mapIndexConfig.urls.get(2));
        }
    },
    events: {
        documentReady: function (url_editar, url_delete) {
            _$mapIndexConfig.urls.editUrl = url_editar;
            _$mapIndexConfig.urls.deleteUrl = url_delete;
            hideAllOverlay()
        }
    },
    functions: {
        setConfigureTableActions: function () { },
    },
    urls: {
        edit: 1,
        delete: 2,
        editUrl: '',
        deleteUrl: '',
        get: function (tipo) {
            let url = '';
            switch (tipo) {
                case this.edit:
                    url = _$mapIndexConfig.urls.editUrl;
                    break;
                case this.delete:
                    url = _$mapIndexConfig.urls.deleteUrl;
                    break;
            }
            return url;
        }
    }
}