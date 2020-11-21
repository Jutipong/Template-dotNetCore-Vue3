//=================== Store ===================
const store = Vue.reactive({});
const inqueryModel = Vue.reactive({});
const usertModel = Vue.reactive({});

//================== Initial ==================
function _initialModel(inquery, user) {
    Object.assign(inqueryModel, inquery)
    Object.assign(usertModel, user)
    Object.assign(store, user)
}

function _getStore() {
    return { inqueryModel, usertModel, store };
}