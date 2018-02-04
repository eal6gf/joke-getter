import React from "react";
import JokeList from './JokeList';

class JokeContainer extends React.Component {
  constructor(){
    super()
    const addJoke = this.addJoke.bind(this)
    this.state = {
      jokes: []
    }
  }

  render() {
    return (
      <div>
        <button onClick={this.handleFetchJoke}>Get a Joke!</button>
        <JokeList jokes={this.state.jokes} />
      </div>
    )
  }

  handleFetchJoke(){
    fetch('https://08ad1pao69.execute-api.us-east-1.amazonaws.com/dev/random_joke'
  ).then(response => response.json()).then(json => JokeContainer.addJoke(json))
  }

  static addJoke = (json) => {
    let prevJokes = this.state.jokes
    this.setState(
      {
      jokes: [...prevJokes, json]
      }
    )
  }
}

export default JokeContainer
