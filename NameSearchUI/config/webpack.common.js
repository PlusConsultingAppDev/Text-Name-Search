var webpack = require('webpack');
var path = require('path');
//var HtmlWebpackPlugin = require('html-webpack-plugin');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var helpers = require('./helpers');

const IS_BUILD_VERSION = process.env.IS_BUILD_VERSION = Math.random().toString(36).substring(2)
const IS_APP_SUFFIX = process.env.IS_APP_SUFFIX = "SF";

module.exports = {

	entry: {
		'tabs': ['./src/tabs.ts'],
		'polyfills': ['./src/polyfills.ts'],
		'vendor': ['./src/vendor.ts', './src/vendor.css'],
		'framework': ['./src/framework.ts', './src/framework.css'],
		'common': ['./src/common.css'],
		'app': ['./src/main.ts', './src/styles.css'],
		'favicon': ['./src/favicon.png']
	},
	resolve: {
		extensions: ['.ts', '.js']
	},
	module: {
		rules: [
			{
				test: /\.html$/,
				loader: 'html-loader'
			}, {
				test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])$/,
				loader: 'url-loader?limit=10000&mimetype=application/font-woff&name=assets/[name].[ext]'
			}, {
				test: /\.(ttf|eot|svg)(\?v=[0-9]\.[0-9]\.[0-9])$/,
				loader: 'file-loader?name=assets/[name].[ext]'
			}, {
				test: /logo\.svg$/,
				loader: 'file-loader?name=server-assets/[name].[ext]'
			}, {
				test: /^((?!(logo\.svg)|didata\.svg).)*\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
				loader: 'file-loader?name=assets/[name].[ext]'
			}/* , {
				test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
				loader: 'file-loader?name=assets/[name].[ext]'
			} */, {
				test: /\.css$/,
				include: helpers.root('src', 'app'),
				loader: 'raw-loader'
			}
		]
	},

	plugins: [
		/* new webpack.ContextReplacementPlugin(
			// The (\\|\/) piece accounts for path separators in *nix and Windows
			/angular(\\|\/)core(\\|\/)@angular/,
			helpers.root('./src'), // location of your src
			{} // a map of your routes
		), */
		new webpack.ContextReplacementPlugin(/\@angular(\\|\/)core(\\|\/)esm5/, path.join(__dirname, './client')),
		new webpack.optimize.CommonsChunkPlugin({
			name: ['app', 'framework', 'vendor', 'polyfills', 'tabs']
		}),
		new webpack.ProvidePlugin({
			$: "jquery",
			jQuery: "jquery"
		}),
		new webpack.DefinePlugin({
			'process.env': {
				'IS_BUILD_VERSION': JSON.stringify(IS_BUILD_VERSION),
				'IS_APP_SUFFIX': JSON.stringify(IS_APP_SUFFIX)
			}
		}),
		/* new HtmlWebpackPlugin({
			template: 'src/index.html'
		}) */
	]
};