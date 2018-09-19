import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import ApolloClient, { gql } from 'apollo-boost';

import { Query, ApolloProvider } from 'react-apollo';

var apolloClient = new ApolloClient({
  uri: 'http://localhost:55432/graphql'
});;

class App extends Component {

  constructor() {
    super();

    this.state = {
      bookId: 1
    };
  }

  searchBox

  getBook(e) {
    e.preventDefault();
    this.setState({ bookId: this.searchBox.value })
  }

  render() {
    const query = gql`query ($bookId:Int){
                        book(id:$bookId){
                          title
                          authors{
                            name
                          }
                          description
                          imageUrl
                          publicationDate          
                        }
                      }`;
    const { bookId } = this.state;

    return (
      <ApolloProvider client={apolloClient}>
        <div className="App">
          <header className="App-header">
            <img src={logo} className="App-logo" alt="logo" />
            <h1 className="App-title">Welcome to React</h1>
          </header>
          <form onSubmit={this.getBook.bind(this)}>
            <div className="input-group">
              <span className="input-group-label">Book ID</span>
              <input ref={c => this.searchBox = c} className="input-group-field" type="number" />
              <div className="input-group-button">
                <button type="submit" className="button success" ><i className="fas fa-search"></i></button>
              </div>
            </div>
          </form>
          <Query query={query} variables={{ bookId }}>
            {
              ({ loading, error, data }) => {
                if (loading) return <p>Loading...</p>;
                if (error) return <p>Error :(</p>;
                if (!data.book) return <p>No book was found!</p>;

                const { title, imageUrl, description, authors, publicationDate } = data.book;
                return <div className="grid-container full">
                  <div className="grid-x grid-padding-x">
                    <div className="cell large-7 grid-x ">
                      <div className="cell large-3">
                        <div className="thumbnail">
                          <img alt={`${title} cover`} src={imageUrl} />
                        </div>
                      </div>
                      <div className="cell large-6 large-offset-1">
                        <h3>{title}</h3>
                        <h4 className="subheader"><sup>{publicationDate}</sup></h4>
                        <dl>
                          <dt>Author(s)</dt>
                          {authors.map(({ name }) => <dd key={name}>{name}</dd>)}
                        </dl>
                      </div>
                      <div className="cell large-11">
                        <p dangerouslySetInnerHTML={{ __html: description }}></p>
                      </div>
                    </div>
                    <div className="cell large-5">
                      <h5>Comments</h5>
                      
                      <div className="callout">
                      </div>
                    </div>
                  </div>
                </div>
              }
            }
          </Query>
        </div>
      </ApolloProvider>
    );
  }
}

export default App;
