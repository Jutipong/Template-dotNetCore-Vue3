function _vtable(root, options, columns,emit) {
    const { onMounted, ref } = Vue;

    const titleMessage = ref('');
    let datatableFunction = null;

    if (options.noRow) {
        columns.unshift({ title: "No", data: null, sClass: "text-center", bSortable: false });
    }

    if (options.btnView) {
        columns.push({
            title: _Enum.Action.VIEW.Text,
            data: null,
            sClass: "text-center",
            width: "32px",
            bSortable: false,
            render: function () {
                return '<a class="text-success" data-action=' + _Enum.Action.VIEW.Text + ' href="javascript:;"><i class="fa fa-edit"></i></a>';
            }
        });
    }

    if (options.btnDelete) {
        columns.push({
            title: _Enum.Action.Delete.Text,
            data: null,
            sClass: "text-center",
            width: "32px",
            bSortable: false,
            render: function () {
                return '<a class="text-danger" data-action=' + _Enum.Action.Delete.Text + ' href="javascript:;"><i class="fa fa-trash"></i></a>';
            }
        });
    }

    onMounted(() => {
        datatableFunction = $(root.value).dataTable({
            lengthChange: true,
            processing: false,
            searching: false,
            pageLength: _Config.DataTable.PageLength,
            serverSide: true,
            responsive: true,
            language: {
                emptyTable: "ไม่พบข้อมูล",
                paginate: {
                    previous: 'ก่อนหน้า',
                    next: 'ถัดไป'
                },
                lengthMenu: "แสดง _MENU_ แถว",
            },
            ajax: {
                async: true,
                url: options.url,
                type: "POST",
                data: function (d) {
                    if (_.isEmpty($('#' + options.formSubmit).serializeArray())) {
                        return d;
                    } else {
                        return $('#' + options.formSubmit).serializeArray().reduce(function (a, x) {
                            d[x.name] = x.value;
                            return d;
                        }, {});
                    }
                },
                beforeSend: function () {
                    _BlockUI();
                },
                complete: function () {
                    _UnBlockUI();
                },
                error: function (xhr) {
                    SessionExpired(xhr);
                }
            },
            columns: columns,
            order: [[options.sortingby, options.orderby]],
            fnRowCallback: function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                if (!options.noRow) return nRow;
                var info = this.api().page.info();
                $('td:eq(0)', nRow).html(iDisplayIndex + info.start + 1).addClass("text-center");
                return nRow;
            },
            fnDrawCallback: function (oSettings) {
                $('.pagination').addClass("pull-right");
                var info = this.api().page.info();
                var pageInfo = '';
                if (info.recordsTotal > 0) {
                    pageInfo = 'หน้า ' + parseFloat((info.page + 1)) + '/' + parseFloat(info.pages) + ' แสดงลำดับที่ ' + parseFloat((info.start + 1)) + ' ถึง ' + parseFloat(((info.start + info.length) <= info.recordsTotal ? info.start + info.length : info.recordsTotal)) + ' จาก ' + parseFloat(info.recordsTotal) + ' รายการ';
                } else {
                    pageInfo = 'หน้า ' + 0 + '/' + 0 + ' แสดงลำดับที่ ' + 0 + ' ถึง ' + 0 + ' จาก ' + 0 + ' รายการ';
                }
                $(`#${$(this).attr('id')}_info`).text(pageInfo)
                titleMessage.value = '<i class="fa fa-list"></i>' + ' ทั้งหมด ' + parseFloat(info.recordsTotal) + " รายการ"
                $(this).attr("style", "width:100%");
                $(`[name=${$(this).attr('id')}_length]`).select2({ minimumResultsForSearch: -1 });
            },
        }).on('click', 'a', 'tr', function () {
            let obj = datatableFunction.fnGetData($(this).parents('tr')[0]);
            emit('action', {
                action: $(this).attr('data-action'),
                data: _.cloneDeep(obj)
            });
        });
        setTimeout(() => { emit('update:table', datatableFunction); }, 100);
    });

    return { datatableFunction, titleMessage };
}