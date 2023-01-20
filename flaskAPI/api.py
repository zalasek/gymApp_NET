from flask import Flask, request
from flask_restful import Resource, Api, marshal_with, fields
from flask_sqlalchemy import SQLAlchemy
from datetime import date

app = Flask(__name__)
api = Api(app)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///trainingDB.db'
app.config['SECRET_KEY'] = 'hello'
db = SQLAlchemy(app)


@app.route('/init/')
def init():
    with app.app_context():
        db.create_all()
    return 'database has been initialized'


class Training(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.Date, nullable=False)
    description = db.Column(db.String, nullable=False)
    exercise = db.relationship('Exercise', backref='exercise', lazy=True, cascade="delete, merge, save-update")


class Exercise(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    type = db.Column(db.String, nullable=False)
    training_id = db.Column(db.ForeignKey('training.id'), nullable=False)
    series = db.relationship('Series', backref='series', lazy=True, cascade="delete, merge, save-update")


class Series(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    reps = db.Column(db.Integer, nullable=False)
    weight = db.Column(db.Integer, nullable=False)
    exercise_id = db.Column(db.ForeignKey('exercise.id'), nullable=False)


trainingFields = {
    'id': fields.Integer,
    'date': fields.String,
    'description': fields.String,
}
exerciseFields = {
    'id': fields.Integer,
    'type': fields.String,
    'training_id': fields.Integer
}
seriesFields = {
    'id': fields.Integer,
    'reps': fields.Integer,
    'weight': fields.Integer,
    'exercise_id': fields.Integer
}


class AllTrainingsEP(Resource):
    @marshal_with(trainingFields)
    def get(self):
        all_trainings = Training.query.all()
        return all_trainings

    @marshal_with(trainingFields)
    def post(self):
        data = request.json
        training = Training(description=data['description'], date=date.today())
        db.session.add(training)
        db.session.commit()
        return training


class TrainingEP(Resource):
    @marshal_with(trainingFields)
    def get(self, pk):
        training = Training.query.filter_by(id=pk).first()
        return training

    @marshal_with(trainingFields)
    def put(self, pk):
        data = request.json
        training = Training.query.filter_by(id=pk).first()
        training.date = data['date']
        training.description = data['description']
        db.session.commit()
        return training

    @marshal_with(trainingFields)
    def delete(self, pk):
        training = Training.query.filter_by(id=pk).first()
        db.session.delete(training)
        db.session.commit()
        all_trainings = Training.query.all()
        return all_trainings


class AllExercisesEP(Resource):
    @marshal_with(exerciseFields)
    def get(self):
        all_exercises = Exercise.query.all()
        return all_exercises

    @marshal_with(exerciseFields)
    def post(self):
        data = request.json
        exercise = Exercise(training_id=data['training_id'], type=data['type'])
        db.session.add(exercise)
        db.session.commit()
        return exercise


class ExercisesInTrainingEP(Resource):
    @marshal_with(exerciseFields)
    def get(self, training_pk):
        exercises_in_training = Exercise.query.filter_by(training_id=training_pk).all()
        return exercises_in_training


class ExerciseEP(Resource):
    @marshal_with(exerciseFields)
    def get(self, pk):
        exercise = Exercise.query.filter_by(id=pk).first()
        return exercise

    @marshal_with(exerciseFields)
    def put(self, pk):
        data = request.json
        exercise = Exercise.query.filter_by(id=pk).first()
        exercise.type = data['type']
        exercise.training_id = data['training_id']
        db.session.commit()
        return exercise

    @marshal_with(exerciseFields)
    def delete(self, pk):
        exercise = Exercise.query.filter_by(id=pk).first()
        db.session.delete(exercise)
        db.session.commit()
        all_exercises = Exercise.query.all()
        return all_exercises


class AllSeriesEP(Resource):
    @marshal_with(seriesFields)
    def get(self):
        all_series = Series.query.all()
        return all_series

    @marshal_with(seriesFields)
    def post(self):
        data = request.json
        series = Series(exercise_id=data['exercise_id'], reps=data['reps'], weight=data['weight'])
        db.session.add(series)
        db.session.commit()


class SeriesInExerciseEP(Resource):
    @marshal_with(seriesFields)
    def get(self, exercise_pk):
        series_in_exercise = Series.query.filter_by(exercise_id=exercise_pk).all()
        return series_in_exercise


class SeriesEP(Resource):
    @marshal_with(seriesFields)
    def get(self, pk):
        series = Series.query.filter_by(id=pk).first()
        return series

    @marshal_with(seriesFields)
    def put(self, pk):
        data = request.json
        series = Series.query.filter_by(id=pk).first()
        series.exercise_id = data['exercise_id']
        series.reps = data['reps']
        series.weight = data['weight']
        db.session.commit()
        return series

    @marshal_with(seriesFields)
    def delete(self, pk):
        series = Series.query.filter_by(id=pk).first()
        db.session.delete(series)
        db.session.commit()
        all_series = Series.query.all()
        return all_series


api.add_resource(AllTrainingsEP, '/all_trainings')
api.add_resource(TrainingEP, '/training/<int:pk>')
api.add_resource(AllExercisesEP, '/all_exercises')
api.add_resource(ExercisesInTrainingEP, '/exercises_in_training/<int:training_pk>')
api.add_resource(ExerciseEP, '/exercise/<int:pk>')
api.add_resource(AllSeriesEP, '/all_series')
api.add_resource(SeriesInExerciseEP, '/series_in_exercise/<int:exercise_pk>')
api.add_resource(SeriesEP, '/series/<int:pk>')


if __name__ == '__main__':
    app.run(debug=True)
