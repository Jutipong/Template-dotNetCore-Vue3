function _vnumber(root, value, precision, maxvalue, emit) {
    const { onMounted, ref, watch } = Vue;

    const amount = ref(null);

    onMounted(() => {
        $(root.value).number(true, precision)
        if (_.isNumber(value)) {
            if (value === 0) {
                amount.value = getStringDigits();
            }
            else if (_isNull(value)) {
                amount.value = null;
            }
            else if (value > 0) {
                amount.value = $.number(value, precision);
            }
        }
    });

    function emitValue() {
        if (!_isNull(amount.value)) {
            let strnum = amount.value.replace(/,/g, '');
            let numvalue = (parseFloat(strnum));
            if (numvalue > maxvalue && maxvalue != 0) {
                amount.value = getStringDigits();
                emit('update:value', 0);
            }
            else if (numvalue < 0) {
                amount.value = 0;
                emit('update:value', 0);
            } else {
                emit('update:value', numvalue);
            }
        }
    }
    function getStringDigits() {
        let digitstr = "0.";
        for (let i = 0; i < precision; i++) {
            digitstr += "0";
        }
        return digitstr;
    }
    function handleBlur() {
        if ($(root.value).val() === '') {
            amount.value = null;
            emit('update:value', null);
        }
    }

    watch(() => value, (val) => {
        if (val === 0) {
            let digitstr = "0.";
            for (let i = 0; i < precision; i++) {
                digitstr += "0";
            }
            amount.value = digitstr;
            $(root.value).val(value);
        }
        if (_isNull(val)) {
            amount.value = null;
            $(root.value).val(null);
        }
    });

    return { amount, emitValue, handleBlur };
}