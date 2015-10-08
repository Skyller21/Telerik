SELECT w.Id, w.Name,l.Name,e.Explanation, w1.Name,l1.Name,  e1.Explanation FROM Words w
JOIN Translations t ON w.Id = t.WordId
JOIN Words w1 ON w1.Id = t.TranslationId
JOIN Explanations e ON e.Id = w.ExplanationId
JOIN Explanations e1 ON e1.Id = w1.ExplanationId
JOIN Languages l ON w.LanguageId = l.Id
JOIN Languages l1 ON w1.LanguageId = l1.Id