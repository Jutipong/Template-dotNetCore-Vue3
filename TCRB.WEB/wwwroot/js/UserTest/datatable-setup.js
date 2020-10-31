function _datatableSetup(url) {

    const { ref, reactive, toRef, readonly } = Vue;

    const tableSetup = reactive({
        columns: [
            { title: "ชื่อ", data: "Name", sClass: "text-center", bSortable: true },
            { title: "นามสกุล", data: "Last", sClass: "text-center" },
            { title: "CreateBy", data: "CreateBy", sClass: "text-center", bSortable: true },
            {
                title: "CreateDate", data: "CreateDate", width: "140px", sClass: "text-center", bSortable: true,
                render: (item) => { return _DDMMYYYYHHmmss(item); }
            },
            { title: "UpdateBy", data: "UpdateBy", sClass: "text-center", bSortable: true },
            {
                title: "UpdateDate", data: "UpdateDate", width: "140px", sClass: "text-center", bSortable: true,
                render: (item) => { return _DDMMYYYYHHmmss(item); }
            },
            { title: "สถานะ", data: "IsActive", sClass: "text-center", bSortable: true },
        ],
        options: {
            formSubmit: 'formInquiry',
            url: url,
            noRow: true,
            sortingby: 4,
            orderby: _Config.DataTable.DESC,
            btnAction: false,
            btnView: true,
            btnDelete: true
        }
    });
    return { tableSetup };
}