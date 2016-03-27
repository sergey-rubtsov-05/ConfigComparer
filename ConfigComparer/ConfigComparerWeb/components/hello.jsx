var React = require('React');
var TextField = require('material-ui/lib/text-field').default;

module.exports = React.createClass({
    getInitialState: function () {
        return {text: undefined}
    },
    
    getDefaultProps: function () {
        return {text: "World"}
    },
    
    onTextChange: function (e) {
        e.preventDefault();
        this.setState({text: e.target.value});
    },
    
    render: function() {
        var text;
        if (this.state.text) {
            text = this.state.text;
        } else {
            text = this.props.text;
        }
        return (
            <div>
                <TextField id="helloTextField" hintText="Enter name" value={this.state.text} onChange={this.onTextChange} />
                <h1>Hello, {text}!</h1>
            </div>);
    }
});