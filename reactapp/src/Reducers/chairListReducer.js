const chairListReducer = (state = ["name"], action) => {
    switch(action.type) {
        case "ADD_CHAIR":
            const chairs = state.map( chair => chair );
            chairs.push(action.newChair);
            return chairs;
        default:
            return state;
    }
}

export default chairListReducer;