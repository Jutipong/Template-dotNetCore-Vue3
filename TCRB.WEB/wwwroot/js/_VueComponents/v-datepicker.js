function vdatepicker(root, props, emit) {
    const { onMounted, ref, watch, computed } = Vue;
    const valueDate = ref(null);

    onMounted(() => {
        $(root.value).datepicker({
            format: "dd/mm/yyyy",
            autoclose: false,
            todayHighlight: true,
            language: _Config.DatePicker.language.Th
        }).datepicker('setDate', _isNull(props.date) ? null : props.date)
            .change(() => {
                let date = $(root.value).val();
                emit('update:date', _isNull(date) ? null : DateParse(date));
            });

        SetStartDate(props.startdate);
        SetEndDate(props.enddate);
    });

    function SetStartDate(val) {
        $(root.value).datepicker('setStartDate', _isNull(val) ? false : val);
    }
    function SetEndDate(val) {
        $(root.value).datepicker('setEndDate', _isNull(val) ? false : val);
    }
    function DateParse(val) {
        const [day, month, year] = val.split("/");
        const _date = dayjs(`${year}/${month}/${day}`).add(-543, 'year').format('DD/MM/YYYY')
        return _date;
    }

    watch(() => props.startdate, (val) => SetStartDate(val));
    watch(() => props.enddate, (val) => SetEndDate(val));
    watch(() => props.date, (val) => $(root.value).datepicker('setDate', _isNull(val) ? null : val))
    watch(() => props.date, (val) => {
        if (!_isNull(props.date)) {
            valueDate.value = DateParse($(root.value).val());
        } else {
            valueDate.value = null;
        }
    });

    const name = computed(() => props.name);

    return { name, valueDate };
}