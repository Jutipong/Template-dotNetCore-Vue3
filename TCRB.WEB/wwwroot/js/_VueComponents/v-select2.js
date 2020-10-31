function _vselect2(root, props, emit) {
    const { onMounted, ref, watch } = Vue;

    onMounted(() => {
        $(root.value).select2({
            data: MapOption(props.options),
            allowClear: props.allowclear,
            placeholder: _isNull(props.placeholder) ? 'All' : props.placeholder,
            language: {
                searching: () => "กำลังค้นหา.......",
                noResults: () => "ไม่พลข้อมูล",
            },
        }).val(CheckAllowClear()).trigger('change')
            .on('change', () => emit('update:value', $(root.value).val()));
    });

    function MapOption(vals) {
        return _.map(vals, (item) => {
            return { id: item.Value, text: item.Text, selected: item.Selected }
        });
    }

    function CheckAllowClear() {
        if (props.allowclear) {
            return (_isNull(props.value) ? null : props.value);
        } else {
            if (_.isArray(props.options) && props.options.length > 0) {
                let _selected = _.find(props.options, (item) => item.Selected === true)
                if (_selected) {
                    return _selected.Value;
                } else {
                    return _.first(props.options).Value
                }
            } else {
                return null;
            }
        }
    }

    watch(() => props.value, (value) => {
        $(root.value).val(value).trigger('change');
        emit('update:value', value);
    });
}