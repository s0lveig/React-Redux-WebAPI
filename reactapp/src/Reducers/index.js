import {combineReducers } from 'redux';
import todoListReducer from './todoListReducer';

const allReducers = combineReducers(
    {
        todoList: todoListReducer
    }
);

export default allReducers;