import React from "react";
import Joke from './Joke';

class JokeList extends React.Component {

  render() {
    debugger
    return (
      <div>
        {this.buildJokeList()}
      </div>
    )
  }
  buildJokeList = () => {
    debugger
    return this.props.jokes.map( j => <Joke joke={j} />)
  }
}
export default JokeList
