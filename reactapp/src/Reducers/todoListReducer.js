const todoListReducer = (state = [], action) => {
    switch(action.type) {
        case "ADD_TODO":
            const todoList = state.map( todo => todo );
            todoList.push(action.newTodo);
            return todoList;
        default:
            return state;
    }
}

export default todoListReducer;