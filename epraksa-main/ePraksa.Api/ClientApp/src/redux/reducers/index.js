import { combineReducers } from 'redux';
import student from '../reducers/student';


let reducers = {
 student
};

const rootReducer = combineReducers(reducers);

export default rootReducer;