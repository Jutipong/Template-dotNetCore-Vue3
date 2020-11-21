//=================== Store ===================
const store = Vue.reactive({});
const inqueryModel = Vue.reactive({});
const usertModel = Vue.reactive({});

//================== Initial ==================
const initialModel = (inquery, user) => {
    Object.assign(inqueryModel, inquery)
    Object.assign(usertModel, user)
    Object.assign(store, user)
}

const getStore = () => {
    return { inqueryModel, usertModel, store };
}