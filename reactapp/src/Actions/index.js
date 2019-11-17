export const addTodo = (newTodo) => {
    return {
        type: "ADD_TODO",
        newTodo: {
            title: ""
        }
    }
}