var webpack = require('webpack');
var webpackMerge = require('webpack-merge');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var commonConfig = require('./webpack.common.js');
var helpers = require('./helpers');
var OptimizeCssAssetsPlugin = require('optimize-css-assets-webpack-plugin');
let ngtools = require('@ngtools/webpack');

const ENV = process.env.NODE_ENV = process.env.ENV = 'production';

module.exports = webpackMerge(commonConfig, {
	devtool: 'source-map',
	cache: false,
	module: {
		rules: [
			{
				test: /\.ts$/,
				loaders: ['@ngtools/webpack']
			}, {
				test: /\.css$/,
				exclude: helpers.root('src', 'app'),
				loader: ExtractTextPlugin.extract({
					fallback: 'style-loader', use: [
						{ loader: 'css-loader', options: { minimize: true } }
					]
				})
			}
		]
	},
	output: {
		path: helpers.root('dist'),
		publicPath: '/storefront/',
		filename: '[name].js?v=[hash]',
		chunkFilename: '[id].chunk.js'
	},
	plugins: [
		new webpack.DefinePlugin({
			'process.env': {
				'ENV': JSON.stringify(ENV)
			}
		}),
		new ngtools.AngularCompilerPlugin({
			tsConfigPath: helpers.root('tsconfig-aot.json'),
			entryModule: helpers.root('src', 'app', 'app.module#AppModule'),
		}),
		new webpack.NoEmitOnErrorsPlugin(),
		new webpack.optimize.UglifyJsPlugin({ // https://github.com/angular/angular/issues/10618
			mangle: {
				keep_fnames: true
			},
			output: {
				comments: false,
			},
			sourceMap: false
		}),
		new ExtractTextPlugin('[name].css?v=[hash]'),
		new OptimizeCssAssetsPlugin({
			assetNameRegExp: /app\.css$|framework\.css$/,
			cssProcessorOptions: { discardComments: { removeAll: true }, sourceMap: false }
		}),


		new webpack.LoaderOptionsPlugin({
			htmlLoader: {
				minimize: false // workaround for ng2
			}
		}),
		new HtmlWebpackPlugin({
			template: 'src/index-prod.html',
			filename: 'index.html',
		})
	]
});