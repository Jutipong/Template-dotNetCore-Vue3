//function stateTodo() {
//    const { reactive } = Vue;

//    const todos = reactive([])

//    return { todos };
//}
const todosModel = Vue.readonly({ id: null, title: null, description: null });
const todos = Vue.reactive([]);

const revertTodos = Vue.computed(() => {
    return _.map(todos, function (item) {
        return item.title;
    })
});