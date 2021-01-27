import { SET_CURRENT_USER } from "../actions";
import isEmpty from "lodash/isEmpty";
const initialState = {
  isAuthenticated: false,
  student: {},
};

function setCurrentUser(state, action) {
  return {
    isAuthenticated: !isEmpty(action.student),
    student: action.student,
  };
}

export default (state = initialState, action) => {
  switch (action.type) {
    case SET_CURRENT_USER:
      return setCurrentUser(state, action);
    default:
      return state;
  }
};
