import {combineReducers } from 'redux';
import chairListReducer from './chairListReducer';

const allReducers = combineReducers(
    {
        chairList: chairListReducer
    }
);

export default allReducers;