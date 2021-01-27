import { createStore, compose, applyMiddleware } from "redux";
import setAuthorizhationToken from "../utils/SetAuthorizathion";
import rootReducer from "./reducers";

export default function configureStore(initialState) {
  const composeEnhancers =
    window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
  const store = createStore(
    rootReducer,
    initialState,
    composeEnhancers(applyMiddleware())
  );

  setAuthorizhationToken(localStorage.jwtToken);

  return store;
}